#version 400 core

// Mesh
in vec3 position;
in vec2 texture_coordinates;
in vec3 normals;

// Pass to fragment shaders
out vec2 pass_texture_coordinates;
out vec3 pass_surface_normal;

// Fog.
out float vert_visibility;
uniform float fog_density;
uniform float fog_gradiant;
uniform float fog_distance;

// Transforms.
uniform mat4 entity_transform;
uniform mat4 projection_matrix;
uniform mat4 view_matrix;

// Sun And light.
uniform vec3 sun_position;
out vec3 to_light_vector;
out vec3 to_camera_vector;

// Material.
uniform bool material_overide_normals;
uniform vec3 material_normal;

void main(void)
{
    vec4 world_position = entity_transform * vec4(position, 1.0);
    vec4 position_from_camera = view_matrix * world_position;

    pass_texture_coordinates = texture_coordinates;
    
    if (material_overide_normals)
    {
      pass_surface_normal = material_normal;
    }
    else
    {
      pass_surface_normal = (entity_transform * vec4(normals, 0.0)).xyz;
    }

    to_light_vector = sun_position - world_position.xyz;
    to_camera_vector = (inverse(view_matrix) * vec4(0.0, 0.0, 0.0, 1.0)).xyz - world_position.xyz;

    // Fog ---------------------------------------------------------------------
    float d = min(fog_distance - length(position_from_camera.xyz), 0.0);
    vert_visibility = exp(-pow((d * fog_density), fog_gradiant));

    vert_visibility = clamp(vert_visibility, 0.0, 1.0);


    gl_Position =  projection_matrix * position_from_camera;
}
